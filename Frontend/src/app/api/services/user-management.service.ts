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
import { UserRoleDto } from '../models/user-role-dto';

@Injectable({
  providedIn: 'root',
})
export class UserManagementService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiUserManagementGet
   */
  static readonly ApiUserManagementGetPath = '/api/UserManagement';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUserManagementGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserManagementGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<UserResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, UserManagementService.ApiUserManagementGetPath, 'get');
    if (params) {
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
   * To access the full response (for headers, for example), `apiUserManagementGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserManagementGet$Plain(params?: {
  }): Observable<Array<UserResponseDto>> {

    return this.apiUserManagementGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<UserResponseDto>>) => r.body as Array<UserResponseDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUserManagementGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserManagementGet$Json$Response(params?: {
  }): Observable<StrictHttpResponse<Array<UserResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, UserManagementService.ApiUserManagementGetPath, 'get');
    if (params) {
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
   * To access the full response (for headers, for example), `apiUserManagementGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserManagementGet$Json(params?: {
  }): Observable<Array<UserResponseDto>> {

    return this.apiUserManagementGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<UserResponseDto>>) => r.body as Array<UserResponseDto>)
    );
  }

  /**
   * Path part for operation apiUserManagementPost
   */
  static readonly ApiUserManagementPostPath = '/api/UserManagement';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUserManagementPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUserManagementPost$Response(params?: {
    body?: UserRoleDto
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, UserManagementService.ApiUserManagementPostPath, 'post');
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
   * To access the full response (for headers, for example), `apiUserManagementPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUserManagementPost(params?: {
    body?: UserRoleDto
  }): Observable<void> {

    return this.apiUserManagementPost$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiUserManagementRolesGet
   */
  static readonly ApiUserManagementRolesGetPath = '/api/UserManagement/roles';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUserManagementRolesGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserManagementRolesGet$Plain$Response(params?: {
    userID?: string;
  }): Observable<StrictHttpResponse<Array<string>>> {

    const rb = new RequestBuilder(this.rootUrl, UserManagementService.ApiUserManagementRolesGetPath, 'get');
    if (params) {
      rb.query('userID', params.userID, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<string>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUserManagementRolesGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserManagementRolesGet$Plain(params?: {
    userID?: string;
  }): Observable<Array<string>> {

    return this.apiUserManagementRolesGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<string>>) => r.body as Array<string>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUserManagementRolesGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserManagementRolesGet$Json$Response(params?: {
    userID?: string;
  }): Observable<StrictHttpResponse<Array<string>>> {

    const rb = new RequestBuilder(this.rootUrl, UserManagementService.ApiUserManagementRolesGetPath, 'get');
    if (params) {
      rb.query('userID', params.userID, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<string>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUserManagementRolesGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserManagementRolesGet$Json(params?: {
    userID?: string;
  }): Observable<Array<string>> {

    return this.apiUserManagementRolesGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<string>>) => r.body as Array<string>)
    );
  }

}
