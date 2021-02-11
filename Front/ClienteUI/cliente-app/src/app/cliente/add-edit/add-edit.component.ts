import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css'],
})
export class AddEditComponent implements OnInit {
  constructor(private service: SharedService) {}

  @Input() cli: any;
  ClienteID: string = '';
  Nombre: string = '';
  Apellido: string = '';
  Direccion: string = '';

  ngOnInit(): void {
    this.ClienteID = this.cli.ClienteID;
    this.Nombre = this.cli.Nombre;
    this.Apellido = this.cli.Apellido;
    this.Direccion = this.cli.Direccion;
  }
  addCliente() {
    var val = {
      ClienteID: this.ClienteID,
      Nombre: this.Nombre,
      Apellido: this.Apellido,
      Direccion: this.Direccion,
    };
    this.service.addCliente(val).subscribe((res) => {
      alert(res.toString());
    });
  }

  updateCliente() {
    var val = {
      ClienteID: this.ClienteID,
      Nombre: this.Nombre,
      Apellido: this.Apellido,
      Direccion: this.Direccion,
    };
    this.service.updateCliente(val).subscribe((res) => {
      alert(res.toString());
    });
  }
}
