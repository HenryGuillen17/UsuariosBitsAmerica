import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserModel } from '../models/userModel';

@Injectable()
export class UsuariosService {
  private serviceMainRoute = 'https://localhost:44328/api/Usuario';

  constructor( private httClient: HttpClient ) {
  }

  listado() {
    return this.httClient.get( this.serviceMainRoute ).pipe( map( res => res as UserModel[] ) );
  }

  crear( usuario: UserModel) {
    return this.httClient.post( this.serviceMainRoute, usuario ).pipe( map( res => res as UserModel) );
  }
}
