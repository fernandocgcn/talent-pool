import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';

export class BaseService {

  protected readonly httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  protected handleError(httpErrorResponse: HttpErrorResponse) {
    let errorMessage: string = '';
    if (httpErrorResponse.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = httpErrorResponse.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${httpErrorResponse.status}
Mensagem: ${httpErrorResponse.message}`;
    }
    console.error(httpErrorResponse.error);
    return throwError(errorMessage);
  };
}
