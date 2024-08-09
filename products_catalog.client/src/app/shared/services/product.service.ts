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
}
