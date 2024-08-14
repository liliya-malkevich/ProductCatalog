import { Inject, Injectable } from '@angular/core';
import { HttpService } from './config/http.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProduct } from '../../models/product';

@Injectable()
export class ProductService extends HttpService {
  constructor(
    protected override http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    super(http);
  }

  public getProducts(): Observable<IProduct[]> {
    return this.sendRequest(this.baseUrl + `api/Product`);
  }

  public addProduct(product: IProduct): Observable<IProduct> {
    return this.sendRequest(this.baseUrl + `api/Product`, 'POST', product);
  }

  public deleteProduct(id: number): Observable<IProduct> {
    return this.sendRequest(this.baseUrl + `api/Product/${id}`, 'DELETE');
  }

  public updateProduct(product: IProduct): Observable<IProduct> {
    return this.sendRequest(this.baseUrl + `api/Product`, 'PUT', product);
  }
}
