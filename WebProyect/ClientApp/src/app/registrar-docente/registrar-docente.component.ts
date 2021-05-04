import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';
import { Docente } from '../models/docente';
import { DocentesService } from '../services/docentes.service';
import { FormGroup, FormBuilder, Validators, AbstractControl, FormControl} from '@angular/forms';

@Component({
  selector: 'app-registrar-docente',
  templateUrl: './registrar-docente.component.html',
  styleUrls: ['./registrar-docente.component.css']
})
export class RegistrarDocenteComponent implements OnInit {
  docente : Docente;
  public formDocente: FormGroup;
  constructor(private service: DocentesService, private modalService: NgbModal, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.docente=new Docente();
  }

 

  get controls() { 
    return this.formDocente.controls;
  }


    
    
    

  guardar(){
    this.docente=this.formDocente.value;
    this.service.post(this.docente).subscribe(resultado=>{
      if(resultado!=null){
        this.docente=resultado;
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha agregado un docente';
      }
    });
  }

}
