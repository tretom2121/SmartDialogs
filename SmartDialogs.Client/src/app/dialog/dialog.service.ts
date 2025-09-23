import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DialogState } from './dialog.models';

@Injectable({
  providedIn: 'root'
})
export class DialogService {
  // Make sure this points to the HTTPS address from launchSettings.json
  private apiUrl = 'https://localhost:7278/Dialog';

  constructor(private http: HttpClient) { }

  startDialog(): Observable<DialogState> {
    return this.http.get<DialogState>(`${this.apiUrl}/start`);
  }

  getNextState(currentState: DialogState): Observable<DialogState> {
    return this.http.post<DialogState>(`${this.apiUrl}/next`, currentState);
  }
}
