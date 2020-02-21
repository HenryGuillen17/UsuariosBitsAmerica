import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UserModel } from './models/userModel';
import { UsuariosService } from './services/usuarios.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'usuarios-bits-america';


  public tiposDocumento = [
    { idTipoDocumento: 1, tipoDocumento: 'Cedula de Ciudadania'},
    { idTipoDocumento: 2, tipoDocumento: 'Cedula de Extranjeria'},
    { idTipoDocumento: 3, tipoDocumento: 'Tarjeta de Identidad'},
    { idTipoDocumento: 4, tipoDocumento: 'Pasaporte'},
    /*'Cedula de Ciudadania', 'Cedula de Extranjeria', 'Tarjeta de Identidad', 'Pasaporte'*/
  ];
  public ciudades = [
    { ciudadId: 1, descripcion: 'Bogota'},
    { ciudadId: 2, descripcion: 'Medellin'},
    { ciudadId: 3, descripcion: 'Bucaramanga'}
  ];

  public usersForm: FormGroup;
  public formSubmitted = false;
  public emailConfirmmed = false;

  get userFormControls() {
    return this.usersForm.controls;
  }

  constructor(private fBuilder: FormBuilder,
              private userService: UsuariosService) {
  }

  ngOnInit() {
    this.initForm();
  }

  private initForm() {
    this.usersForm = this.fBuilder.group( {
      primerNombre: [null, [Validators.required, Validators.maxLength(10)]],
      segundoNombre: [null, [Validators.maxLength(50)]],
      primerApellido: [null, [Validators.required, Validators.maxLength(50)]],
      segundoApellido: [null, [Validators.maxLength(50)]],
      tipoDocumento: [1, [Validators.required]],
      numeroDocumento: [null, [Validators.required, Validators.maxLength(20)]],
      correoElectronico: [null, [Validators.required,
        Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$'), Validators.maxLength(50)]],
      correoElectronicoVerificar: [null, [Validators.required,
        Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$'), Validators.maxLength(50)]],
      direccionResidencia: [null, [Validators.required]],
      idCiudad: [1, [Validators.required]],
      telefono: [null, [Validators.maxLength(25)]],
      celular: [null, [Validators.required, Validators.maxLength(25)]],
    } );
    console.log(this.usersForm);
  }

  private saveUser( userModel: UserModel ) {
    this.userService.crear( userModel ).subscribe( res => {
      // Limpiar formulario
      this.clearModels();
      this.showMessage('Éxito', 'Usuario guardado con Éxito');
    });
  }

  public onSubmit() {
    this.formSubmitted = true;
    if ( this.usersForm.valid ) {
      if ( this.validateEmail() ) {
        this.formSubmitted = false;
        // const user = this.usersForm.value as UserModel;
        const user = this.setUserModel();
        this.saveUser(user);
        console.log(user);
      } else {
        this.formSubmitted = true;
      }
    }
  }

  private setUserModel() {
    const user = new UserModel();
    user.primerNombre = this.userFormControls.primerNombre.value;
    user.segundoNombre = this.userFormControls.segundoNombre.value;
    user.primerApellido = this.userFormControls.primerApellido.value;
    user.segundoApellido = this.userFormControls.segundoApellido.value;
    user.correoElectronico = this.userFormControls.correoElectronico.value;
    user.celular = this.userFormControls.celular.value;
    user.telefono = this.userFormControls.telefono.value;
    user.ciudadId = parseInt(this.userFormControls.idCiudad.value);
    user.direccionResidencia = this.userFormControls.direccionResidencia.value;
    user.tipoDocumento = parseInt(this.userFormControls.tipoDocumento.value);
    user.numeroDocumento = this.userFormControls.numeroDocumento.value;

    return user;
  }

  public validateEmail() {
    const email = this.userFormControls.correoElectronico.value;
    const emailConfirmation = this.userFormControls.correoElectronicoVerificar.value;

    if ( email && emailConfirmation && (email === emailConfirmation) ) {
      this.emailConfirmmed = true;
      return true;
    } else {
      this.emailConfirmmed = false;
      return false;
    }
  }

  private clearModels() {
    this.usersForm.reset();
    this.initForm();
  }

  private showMessage(titulo: string, msg: string) {
    Swal.fire({
      title: titulo,
      text: msg,
      icon: 'success',
      showCancelButton: false,
      confirmButtonColor: '#28a745'
    }).then((result) => {
    });
  }

  public test() {
    console.log(this.usersForm);
  }
}
