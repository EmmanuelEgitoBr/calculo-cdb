import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-formulario',
  standalone: true,
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})
export class FormularioComponent {
  formulario: FormGroup;
  resposta: any;

  constructor(private fb: FormBuilder, private apiService: ApiService) {
    this.formulario = this.fb.group({
      valorInicial: [''],
      meses: ['']
    });
  }

  enviarFormulario() {
    const dados = this.formulario.value;
    this.apiService.enviarDados(dados).subscribe(
      (res) => {
        this.resposta = res; // Exibe a resposta na tela
      },
      (erro) => {
        console.error('Erro ao enviar os dados:', erro);
      }
    );
  }
}
