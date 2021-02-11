import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {

  constructor(private service:SharedService) { }

  ClienteList:any=[];

  ModalTitle: string="";
  ActivateAddEditCliComp:boolean=false;
  cli:any;

  ngOnInit(): void {
    this.refreshCliList();
  }
  addClick(){
    this.cli={
      ClienteID:0,
      Nombre:"",
      Apellido:"",
      Dirreccion:"",
    }
    this.ModalTitle="Add Client";
    this.ActivateAddEditCliComp=true;
  }

  closeClick(){
    this.ActivateAddEditCliComp=false;
    this.refreshCliList();
  }
  EditClick(item: any){
    this.cli.item;
    this.ModalTitle="Edit Client";
    this.ActivateAddEditCliComp=true;
  }

  refreshCliList(){
    this.service.getClienteList().subscribe(data=>{
      this.ClienteList=data;
    })
  }
}
