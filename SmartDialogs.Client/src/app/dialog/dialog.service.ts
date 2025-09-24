import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DialogState } from './dialog.models';

@Injectable({
  providedIn: 'root',
})
export class DialogService {
  private apiUrl = 'https://localhost:7278/dialog';

  constructor(private http: HttpClient) {}

  start(key: string): Observable<DialogState> {
    return this.http.get<DialogState>(`${this.apiUrl}/start/${key}`);
  }

  next(key: string, currentState: DialogState): Observable<DialogState> {
    return this.http.post<DialogState>(`${this.apiUrl}/next/${key}`, currentState);
  }
}
