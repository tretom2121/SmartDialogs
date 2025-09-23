import { Routes } from '@angular/router';
import { DataComponent } from './data/data.component';
import { DialogComponent } from './dialog/dialog.component';

export const routes: Routes = [
  { path: '', redirectTo: '/data', pathMatch: 'full' },
  { path: 'dialog', component: DialogComponent },
  { path: 'data', component: DataComponent }
];
