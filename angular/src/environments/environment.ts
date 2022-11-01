import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'ActivApartment',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44357/',
    redirectUri: baseUrl,
    clientId: 'ActivApartment_App',
    responseType: 'code',
    scope: 'offline_access ActivApartment',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44357',
      rootNamespace: 'ActivApartment',
    },
  },
} as Environment;
