import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { WeatherComponent } from './weather/weather.component';

import { NgModule } from '@angular/core';
import { PreloadAllModules, Routes, RouterModule } from '@angular/router';

import { AuthGuard, CanDeactivateGuard, UserProfileService } from './core';
import { PageNotFoundComponent } from './pageNotFound.component';

/***************************************************************
* Lazy Loading to Eager Loading
*
* 1. Remove the module and NgModule imports in `app.module.ts`
*
* 2. Remove the lazy load route from `app.routing.ts`
*
* 3. Change the module's default route path from '' to 'pathname'
*****************************************************************/
const routes: Routes = [
  {
    path: '',
    loadChildren: './home/home.module#HomeModule'
  },
  {
    path:'weather',
    loadChildren: './weather/weather.module#WeatherModule',
  },
  {
    path:'counter',
    loadChildren: './counter/counter.module#CounterModule',
  },
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule],
  providers: [
    AuthGuard,
    CanDeactivateGuard,
    UserProfileService
  ]
})
export class AppRoutingModule { }