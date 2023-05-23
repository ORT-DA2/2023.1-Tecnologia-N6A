import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuard } from './_guards/Authentication/authentication.guard';
// import { AuthorizationGuard } from './_guards/Authentication/authorization.guard';
import { LoginRegisterPageComponent } from './_pages/login-register-page/login-register-page.component';
import { ExampleComponent } from './_pages/example-component/example-component.component';
import { FatherComponent } from './_pages/father-component/father-component.component';

const routes: Routes = [
  {
    path: '',
    component: LoginRegisterPageComponent
  },
  {
    path: 'binding',
    component: FatherComponent,
  },
  {
    path: 'example',
    component: ExampleComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
