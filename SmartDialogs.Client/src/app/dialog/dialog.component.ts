import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DialogService } from './dialog.service';
import { DialogState } from './dialog.models';

@Component({
  selector: 'app-dialog',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './dialog.component.html',
  // styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {
  currentState?: DialogState;
  // This object will hold the user's answers
  formValues: { [key: string]: any } = {};

  constructor(private dialogService: DialogService) {}

  ngOnInit(): void {
    // Start the dialog when the component loads
    this.dialogService.startDialog().subscribe(state => {
      this.currentState = state;
    });
  }

  // Called when the user clicks the "Next" button
  onNext(): void {
    if (this.currentState) {
      // Merge the user's answers into the state's parameters
      this.currentState.parameters = { ...this.currentState.parameters, ...this.formValues };

      this.dialogService.getNextState(this.currentState).subscribe(newState => {
        this.currentState = newState;
        // Clear form values for the next step
        this.formValues = {};
      });
    }
  }
}
