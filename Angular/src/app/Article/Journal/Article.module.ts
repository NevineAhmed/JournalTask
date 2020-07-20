import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ArticleRoutingModule } from './Article-routing.module';
 
import { ArticleComponent } from './Articles/Article.component';


import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {NgxPaginationModule} from 'ngx-pagination';


@NgModule({
  declarations: [   ArticleComponent],
  imports: [
    CommonModule,
    ArticleRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    NgxPaginationModule
    
  ]
})
export class ArticleModule { }
