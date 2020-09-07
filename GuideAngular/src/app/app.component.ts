import { Component, OnInit, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Autor } from './autores';
import { FormGroup, FormBuilder, FormArray, FormControl } from '@angular/forms';
import { BuiltinVar } from '@angular/compiler';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'GuideAngular';
  urlServer: string = "https://localhost:44366/";

  cadastroForm: FormGroup;
  lstAutores: Autor[];


  get autores(): FormArray {
    return this.cadastroForm.get('autores') as FormArray;
  }

  constructor(private http: HttpClient, private _formBuilder: FormBuilder) { }

  ngOnInit() {
    this.cadastroForm = new FormGroup({
      qntAutor: new FormControl(),
      autores: this._formBuilder.array([this.createFormGroup()])

    });
  }

  adicionarAutor() {
    this.http.post(this.urlServer + "api/autores", this.cadastroForm.value.autores).subscribe({
      next: data =>
        this.receberListaAutores()
      ,
      error: error => console.error('Erro!', error)
    })
  }

  adicionarQuantidade() {

    const quantidade = this.cadastroForm.value.qntAutor;

    for (var i = 1; i < quantidade; i++) {
      this.autores.push(this.createFormGroup());
    }

    document.getElementById('btnSalvar').setAttribute("disabled", "disabled");
  }

  createFormGroup() {
    return this._formBuilder.group({
      nome: ['']
    });
  }

  receberListaAutores() {
    this.http.get<Autor[]>(this.urlServer + "api/autores")
      .subscribe(data =>
        this.popularTipo(data))
  }

  popularTipo(data: Autor[]) {
    this.lstAutores = data;

    console.log(this.lstAutores);
  }
}


