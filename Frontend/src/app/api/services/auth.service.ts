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

import { UserChangePasswordDto } from '../models/user-change-password-dto';
import { UserLoginDto } from '../models/user-login-dto';
import { UserLoginResponseDto } from '../models/user-login-response-dto';
import { UserRegisterDto } from '../models/user-register-dto';
import { UserResponseDto } from '../models/user-response-dto';

@Injectable({
  providedIn: 'root',
})
export class AuthService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiAuthChangePasswordPut
   */
  static readonly ApiAuthChangePasswordPutPath = '/api/Auth/change-password';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAuthChangePasswordPut()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthChangePasswordPut$Response(params?: {
    body?: UserChangePasswordDto
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, AuthService.ApiAuthChangePasswordPutPath, 'put');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAuthChangePasswordPut$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthChangePasswordPut(params?: {
    body?: UserChangePasswordDto
  }): Observable<void> {

    return this.apiAuthChangePasswordPut$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiAuthRegisterPost
   */
  static readonly ApiAuthRegisterPostPath = '/api/Auth/register';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAuthRegisterPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthRegisterPost$Plain$Response(params?: {
    body?: UserRegisterDto
  }): Observable<StrictHttpResponse<UserResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, AuthService.ApiAuthRegisterPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
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
   * To access the full response (for headers, for example), `apiAuthRegisterPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthRegisterPost$Plain(params?: {
    body?: UserRegisterDto
  }): Observable<UserResponseDto> {

    return this.apiAuthRegisterPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UserResponseDto>) => r.body as UserResponseDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAuthRegisterPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthRegisterPost$Json$Response(params?: {
    body?: UserRegisterDto
  }): Observable<StrictHttpResponse<UserResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, AuthService.ApiAuthRegisterPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
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
   * To access the full response (for headers, for example), `apiAuthRegisterPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthRegisterPost$Json(params?: {
    body?: UserRegisterDto
  }): Observable<UserResponseDto> {

    return this.apiAuthRegisterPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UserResponseDto>) => r.body as UserResponseDto)
    );
  }

  /**
   * Path part for operation apiAuthLoginPost
   */
  static readonly ApiAuthLoginPostPath = '/api/Auth/login';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAuthLoginPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthLoginPost$Plain$Response(params?: {
    body?: UserLoginDto
  }): Observable<StrictHttpResponse<UserLoginResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, AuthService.ApiAuthLoginPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserLoginResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAuthLoginPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthLoginPost$Plain(params?: {
    body?: UserLoginDto
  }): Observable<UserLoginResponseDto> {

    return this.apiAuthLoginPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UserLoginResponseDto>) => r.body as UserLoginResponseDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAuthLoginPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthLoginPost$Json$Response(params?: {
    body?: UserLoginDto
  }): Observable<StrictHttpResponse<UserLoginResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, AuthService.ApiAuthLoginPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserLoginResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAuthLoginPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAuthLoginPost$Json(params?: {
    body?: UserLoginDto
  }): Observable<UserLoginResponseDto> {

    return this.apiAuthLoginPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UserLoginResponseDto>) => r.body as UserLoginResponseDto)
    );
  }

}
