import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

interface Conta {
  id: number;
  nome: string;
  valorInicial: number;
  valorCorrigido: number;
  dataPagamento: Date;
  dataVencimento: Date;
  diasEmAtraso: number;
}

class ContaCadastro {
  Nome: string;
  ValorInicial: number;
  DataPagamento: Date;
  DataVencimento: Date;

  constructor(nome: string, valor: number, dataPagamento: Date, dataVencimento: Date) {
    this.Nome = nome;
    this.ValorInicial = valor;
    this.DataPagamento = dataPagamento;
    this.DataVencimento = dataVencimento;
  }
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] // Corrigido para styleUrls
})
export class AppComponent implements OnInit {
  public forecasts: Conta[] = [];
  private apiURL = 'https://localhost:7278/v1';

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getForecasts();
  }

   getForecasts() {
    this.http.get<Conta[]>(this.apiURL + '/contas').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}

@Component({
  selector: 'app-conta-form',
  templateUrl: './form.component.html',
  styleUrls: ['./app.component.css'] // Corrigido para styleUrls
})
export class ContaFormComponent {
  contaForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.contaForm = this.fb.group({
      nome: ['', Validators.required],
      valor: ['', Validators.required],
      dataPagamento: ['', Validators.required],
      dataVencimento: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.contaForm.valid) {
      const { nome, valor, dataPagamento, dataVencimento } = this.contaForm.value;
      const novaConta = new ContaCadastro(nome, valor, dataPagamento, dataVencimento);
      this.http.post<any>('https://localhost:7278/v1/contas', novaConta).subscribe({
        next: () => {
          console.log('Conta cadastrada com sucesso!');
          this.contaForm.reset();
        },
        error: (error) => {
          console.error('Erro ao cadastrar conta:', error);
        }
      });
    } else {
      console.error('Formulário inválido. Verifique os campos.');
    }
  }
}
