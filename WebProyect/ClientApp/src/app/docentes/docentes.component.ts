import { Component, OnInit } from '@angular/core';
import { Docente } from '../models/docente';
import { DocentesService } from '../services/docentes.service';

@Component({
  selector: 'app-docentes',
  templateUrl: './docentes.component.html',
  styleUrls: ['./docentes.component.css']
})
export class DocentesComponent implements OnInit {

  docentes:Docente[]=[]
  
  constructor(private docenteService: DocentesService) { }

  ngOnInit(): void {
    this.get();
  }

  get(){
    this.docenteService.get().subscribe(resultado=>{
      if(resultado!=null){
        this.docentes=resultado;
      }
      console.log(resultado);
    })
  }

}
