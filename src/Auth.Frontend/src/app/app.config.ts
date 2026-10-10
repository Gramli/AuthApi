import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration, withNoIncrementalHydration } from '@angular/platform-browser';
import { provideHttpClient, withInterceptors, withXhr } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { authInterceptor } from './shared/auth/auth-interceptor.interceptor';
import {provideOptimus} from "@openng/optimus-ui/config";
import Nora from '@openng/optimus-ui-themes/nora';
import {provideAnimationsAsync} from "@angular/platform-browser/animations/async";

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(withNoIncrementalHydration()),
    provideHttpClient(withXhr(), withInterceptors([authInterceptor])),
    provideAnimations(),
    provideAnimationsAsync(),
    provideOptimus({
      theme: {
        preset: Nora,
      }
    })]
};
