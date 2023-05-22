import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {EjemploComponent} from "./ejemplo.component";



@NgModule({
  declarations: [EjemploComponent],
  imports: [
    CommonModule
  ],
  exports:[EjemploComponent]
})
export class EjemploModule { }
