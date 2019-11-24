/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { OrderViewModel } from '../models/order-view-model';
@Injectable({
  providedIn: 'root',
})
class OrderService extends __BaseService {
  static readonly GetPath = '/api/Order/{id}';
  static readonly AddPath = '/api/Order';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param id undefined
   * @return Success
   */
  GetResponse(id: number): __Observable<__StrictHttpResponse<OrderViewModel>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Order/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<OrderViewModel>;
      })
    );
  }
  /**
   * @param id undefined
   * @return Success
   */
  Get(id: number): __Observable<OrderViewModel> {
    return this.GetResponse(id).pipe(
      __map(_r => _r.body as OrderViewModel)
    );
  }

  /**
   * @param order undefined
   * @return Success
   */
  AddResponse(order?: OrderViewModel): __Observable<__StrictHttpResponse<number>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = order;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Order`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'text'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return (_r as HttpResponse<any>).clone({ body: parseFloat((_r as HttpResponse<any>).body as string) }) as __StrictHttpResponse<number>
      })
    );
  }
  /**
   * @param order undefined
   * @return Success
   */
  Add(order?: OrderViewModel): __Observable<number> {
    return this.AddResponse(order).pipe(
      __map(_r => _r.body as number)
    );
  }
}

module OrderService {
}

export { OrderService }
