import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Question-answer.Feature/components/home/home.component';
import { OpeningsComponent } from './Job-application.Feature/components/openings/openings.component';

const routes: Routes = [
  { path: '', redirectTo: '/questionAnswer', pathMatch: 'full' },
  { path: 'questionAnswer', component: HomeComponent },
  { path: 'jobs', component: OpeningsComponent},
  { path: '*', redirectTo: '/questionAnswer' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }