import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateRouteComponent } from './components/routes/create-route/create-route.component';
import { HomeComponent } from './components/home/home.component';
import { CreateTicketComponent } from './components/tickets/create-ticket/create-ticket.component';
import { SeatsInfoComponent } from './components/seats/seats-info/seats-info.component';
import { MyTicketsComponent } from './components/tickets/my-tickets/my-tickets.component';
import { AdminGuard } from './guards/admin.guard';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'auth', loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule)},
  { path: 'routes/create', component: CreateRouteComponent, canActivate: [AdminGuard]},
  { path: 'tickets/book', component: CreateTicketComponent },
  { path: 'seats', component: SeatsInfoComponent },
  { path: 'my-tickets', component: MyTicketsComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
