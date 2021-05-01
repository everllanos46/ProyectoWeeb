import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Solicitud } from '../models/solicitud';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

const ruta = environment.ruta;

@Injectable({
  providedIn: 'root'
})
export class SolicitudService {

  constructor(
    private http: HttpClient,
    private handleErrorService: HandleHttpErrorService
  ) { }

  post(solicitud : Solicitud) : Observable<Solicitud> {
    return this.http.post<Solicitud>(ruta+"api/Solicitud",solicitud).pipe(tap(
      _=>this.handleErrorService.log("Datos Registrados")
    ), catchError(this.handleErrorService.handleError<Solicitud>("Solicitud Registrado",null)) )
  }

  get():Observable<Solicitud[]>{
    return this.http.get<Solicitud[]>(ruta+"api/Solicitud").pipe(
      tap(()=>console.log("Consultado correctamente"))
    )
  }
}
