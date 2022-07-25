/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { UserResponseDto } from '../models/user-response-dto';

@Injectable({
  providedIn: 'root',
})
export class AdminUserService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiAdminUserGetListNrGet
   */
  static readonly ApiAdminUserGetListNrGetPath = '/api/AdminUser/get-list/{nr}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminUserGetListNrGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminUserGetListNrGet$Plain$Response(params: {
    nr: number;
  }): Observable<StrictHttpResponse<Array<UserResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, AdminUserService.ApiAdminUserGetListNrGetPath, 'get');
    if (params) {
      rb.path('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<UserResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminUserGetListNrGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminUserGetListNrGet$Plain(params: {
    nr: number;
  }): Observable<Array<UserResponseDto>> {

    return this.apiAdminUserGetListNrGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<UserResponseDto>>) => r.body as Array<UserResponseDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminUserGetListNrGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminUserGetListNrGet$Json$Response(params: {
    nr: number;
  }): Observable<StrictHttpResponse<Array<UserResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, AdminUserService.ApiAdminUserGetListNrGetPath, 'get');
    if (params) {
      rb.path('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<UserResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminUserGetListNrGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminUserGetListNrGet$Json(params: {
    nr: number;
  }): Observable<Array<UserResponseDto>> {

    return this.apiAdminUserGetListNrGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<UserResponseDto>>) => r.body as Array<UserResponseDto>)
    );
  }

  /**
   * Path part for operation apiAdminUserBanUserIdDelete
   */
  static readonly ApiAdminUserBanUserIdDeletePath = '/api/AdminUser/ban-user/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminUserBanUserIdDelete$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminUserBanUserIdDelete$Plain$Response(params: {
    id: string;
  }): Observable<StrictHttpResponse<UserResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, AdminUserService.ApiAdminUserBanUserIdDeletePath, 'delete');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminUserBanUserIdDelete$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminUserBanUserIdDelete$Plain(params: {
    id: string;
  }): Observable<UserResponseDto> {

    return this.apiAdminUserBanUserIdDelete$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UserResponseDto>) => r.body as UserResponseDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminUserBanUserIdDelete$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminUserBanUserIdDelete$Json$Response(params: {
    id: string;
  }): Observable<StrictHttpResponse<UserResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, AdminUserService.ApiAdminUserBanUserIdDeletePath, 'delete');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminUserBanUserIdDelete$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminUserBanUserIdDelete$Json(params: {
    id: string;
  }): Observable<UserResponseDto> {

    return this.apiAdminUserBanUserIdDelete$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UserResponseDto>) => r.body as UserResponseDto)
    );
  }

}
