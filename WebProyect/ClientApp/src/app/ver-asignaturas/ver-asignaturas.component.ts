import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Asignatura } from '../models/asignatura';
import { PlanAsignatura } from '../models/plan-asignatura';
import { AsignaturaService } from '../services/asignatura.service';
import { PlanasignaturaService } from '../services/planasignatura.service';

@Component({
  selector: 'app-ver-asignaturas',
  templateUrl: './ver-asignaturas.component.html',
  styleUrls: ['./ver-asignaturas.component.css']
})
export class VerAsignaturasComponent implements OnInit {
  asignatura: Asignatura= new Asignatura()
  planAsignatura : PlanAsignatura= new PlanAsignatura();
  constructor(private routeActive: ActivatedRoute, private planAsignaturaService : PlanasignaturaService, private asignaturaService: AsignaturaService) { }

  ngOnInit(): void {
    this.planAsignaturaService.searchAsignatura(this.routeActive.snapshot.params.codigoAsignatura).subscribe(resultado=>{
      if(resultado!=null){
        this.planAsignatura=resultado;    
        this.asignatura=resultado.asignatura
      }
    })
  }

  modify(){
    this.asignaturaService.modify(this.asignatura).subscribe(resultado=>{
      if(resultado!=null){
        alert("Asignatura modificada correctamente");
        console.log(resultado)
      }
    })
  }
  

}
