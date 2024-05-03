import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateRouteComponent } from './components/routes/create-route/create-route.component';
import { HomeComponent } from './components/home/home.component';
import { CreateTicketComponent } from './components/tickets/create-ticket/create-ticket.component';

const routes: Routes = [
  {path:'', component: HomeComponent},
  {path:'routes/create', component: CreateRouteComponent},
  {path:'tickets/book', component: CreateTicketComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
