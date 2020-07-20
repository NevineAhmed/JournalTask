import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './Auth/auth/register/register.component';


const routes: Routes = [{ path:"Auth", loadChildren: () => import('./Auth/auth/auth.module').then(m => m.AuthModule) },
 { path: "Article", loadChildren: () => import('./Article/Journal/Article.module').then(m => m.ArticleModule) },
 { path:"", loadChildren: () => import('./Auth/auth/auth.module').then(m => m.AuthModule) },
{path:"register",component:RegisterComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
