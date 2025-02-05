import { TestBed } from '@angular/core/testing';
import { ApiService } from './api.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('ApiService', () => {
  let service: ApiService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ApiService]
    });

    service = TestBed.inject(ApiService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify(); // Verifica se todas as requisições foram tratadas
  });

  it('deve ser criado', () => {
    expect(service).toBeTruthy();
  });

  it('deve fazer uma requisição Post e retornar os dados esperados', () => {
    const mockDados = { inicialValue: 1000, months: 10 };

    service.enviarDados(mockDados).subscribe(dados => {
      expect(dados).toEqual(mockDados);
    });

    const req = httpMock.expectOne('https://localhost:44332/api/calculations');
    expect(req.request.method).toBe('GET');
    req.flush(mockDados); // Simula a resposta da API
  });

  it('deve lidar com erro da API corretamente', () => {
    const dados: any = {};
    service.enviarDados(dados).subscribe({
      next: () => fail('A chamada deveria falhar'),
      error: (error) => {
        expect(error.message).toBe('Erro ao obter dados');
      }
    });

    const req = httpMock.expectOne('https://localhost:44332/api/calculations');
    req.flush('Erro no servidor', { status: 500, statusText: 'Server Error' });
  });
});
