import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule, JsonPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DialogService } from './dialog.service';
import { DialogState } from './dialog.models';
import { Observable, tap } from 'rxjs';

@Component({
  selector: 'app-dialog',
  standalone: true,
  imports: [CommonModule, FormsModule, JsonPipe],
  templateUrl: './dialog.component.html',
})
export class DialogComponent implements OnInit {
  dialogState$!: Observable<DialogState>;
  currentState: DialogState | null = null;
  formValues: { [key: string]: any } = {};
  showFuelCostWarning = false; // <-- New property for the warning
  private dialogKey!: string;

  constructor(
    private route: ActivatedRoute,
    private dialogService: DialogService
  ) {}

  ngOnInit(): void {
    this.dialogKey = this.route.snapshot.paramMap.get('key')!;
    if (this.dialogKey) {
      this.dialogState$ = this.dialogService.start(this.dialogKey).pipe(
        tap(state => this.initializeState(state))
      );
    }
  }

  onNext(): void {
    if (!this.currentState) return;

    // --- Validation Logic ---
    if (this.currentState.currentState === 'CostParameters') {
      if (!this.formValues['fuelCost']) {
        this.showFuelCostWarning = true;
        return; // Stop execution if validation fails
      }
    }
    // --- End of Validation ---

    const nextState: DialogState = {
      ...this.currentState,
      parameters: {
        ...this.currentState.parameters,
        ...this.formValues
      }
    };

    this.dialogState$ = this.dialogService.next(this.dialogKey, nextState).pipe(
      tap(state => this.initializeState(state))
    );
  }

  selectGoalAndNext(goal: string): void {
    this.formValues['goal'] = goal;
    this.onNext();
  }

  private initializeState(state: DialogState): void {
    this.currentState = state;
    this.formValues = {};
    this.showFuelCostWarning = false; // Reset warning on state change
  }
}
