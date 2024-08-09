import { HttpClient } from '@angular/common/http';
import { alert } from 'devextreme/ui/dialog';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

export class HttpService {
  constructor(protected http: HttpClient) {}

  protected sendRequest<T>(
    url: string,
    method: string = 'GET',
    data: any = {}
  ): Observable<T> {
    let httpParams = data;
    //let httpOptions = { withCredentials: true, body: httpParams };
    let result: Observable<T> = undefined!;
    switch (method) {
      case 'GET':
        result = this.http
          .get<T>(url)
          .pipe(retry(1), catchError(this.handleError));
        break;
      case 'PUT':
        result = this.http
          .put<T>(url, httpParams)
          .pipe(retry(1), catchError(this.handleError));
        break;
      case 'POST':
        result = this.http
          .post<T>(url, httpParams)
          .pipe(retry(1), catchError(this.handleError));
        break;
      case 'PATCH':
        result = this.http
          .patch<T>(url, httpParams)
          .pipe(retry(1), catchError(this.handleError));
        break;
      case 'DELETE':
        result = this.http
          .delete<T>(url)
          .pipe(retry(1), catchError(this.handleError));
        break;
    }

    return result;
  }

  handleError(e: any) {
    let message: string = '';
    if (e) {
      let excMessage: string = '';
      let additionExcMsg: string = '';
      let responseMessage = e.statusText ? e.statusText : '';
      console.error(e);

      if (e.error) {
        message = e.error.title ? e.error.title : '';
        excMessage = e.error.ExceptionMessage ? e.error.ExceptionMessage : '';
      }

      if (e.message) {
        additionExcMsg = e.message ? e.message : '';
      }
      if (e.status === 404) {
        alert(
          '<p style="color:red;">' + 'Запрашиваемый ресурс не найден' + '</p>',
          'Ошибка'
        );
      } else if (e.status === 401) {
        alert(
          '<p style="color:red;">' + 'Время сессии истекло' + '</p>',
          'Ошибка'
        );
      } else {
        alert(
          '<p style="color:red;">' +
            message +
            ' ' +
            excMessage +
            ' ' +
            additionExcMsg +
            ' (' +
            responseMessage +
            ')</p>',
          'Ошибка'
        );
      }
    } else {
      alert('<p style="color:red;">' + 'Неизвестная ошибка' + '</p>', 'Ошибка');
    }

    return throwError(() => {
      return message;
    });
  }
}
