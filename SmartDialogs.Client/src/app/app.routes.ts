import { Routes } from '@angular/router';
import { Home } from './home/home';
import { DialogComponent } from './dialog/dialog.component';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: Home },
  { path: 'dialog/:key', component: DialogComponent }
];
