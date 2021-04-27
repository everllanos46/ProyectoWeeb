import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { PlanasignaturaService } from '../services/planasignatura.service';

@Component({
  selector: 'app-ver-plan-asignatura',
  templateUrl: './ver-plan-asignatura.component.html',
  styleUrls: ['./ver-plan-asignatura.component.css']
})
export class VerPlanAsignaturaComponent implements OnInit {

  constructor(private router: Router, private routeActive: ActivatedRoute, private planAsignaturaService : PlanasignaturaService) { 
    
  }
  ID=''
  abrir(){
    this.router.navigateByUrl('/solicitud/'+this.ID);
  }
  ngOnInit(): void {
    const id=this.routeActive.snapshot.params.codigoAsignatura;
    this.ID=id
  }
  

}
