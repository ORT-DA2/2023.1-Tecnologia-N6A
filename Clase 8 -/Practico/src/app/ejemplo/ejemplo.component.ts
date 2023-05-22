import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-ejemplo',
  templateUrl: './ejemplo.component.html',
  styleUrls: ['./ejemplo.component.css']
})
export class EjemploComponent {
  @Input() pageTitle:string = "Ejemplo Angular de la clase 8"
}
