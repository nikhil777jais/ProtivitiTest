import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'customer', pathMatch: 'full', title: 'customer' },
  { path: 'customer', loadChildren: () => import('./customer/customer.module').then(m => m.CustomerModule), title: 'Welcome !!' },
  { path: '**', redirectTo: 'customer', pathMatch: 'full' } //wildcard route
];

@NgModule({
  imports: [RouterModule.forRoot(routes,
    {
      scrollPositionRestoration: 'top',
      preloadingStrategy: PreloadAllModules
    }
  )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
