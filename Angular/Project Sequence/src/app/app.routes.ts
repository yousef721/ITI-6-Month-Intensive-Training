import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },

  {
    path: 'home',
    loadComponent: () => import('./Pages/home/home').then((m) => m.Home),
  },

  {
    path: 'about',
    loadComponent: () => import('./Pages/about/about').then((m) => m.About),
  },

  {
    path: 'profile',
    loadComponent: () => import('./Pages/profile/profile').then((m) => m.Profile),
  },

  {
    path: 'posts',
    loadComponent: () => import('./Pages/post-list/post-list').then((m) => m.PostList),
  },

  {
    path: 'posts/:id',
    loadComponent: () => import('./Pages/post-details/post-details').then((m) => m.PostDetails),
  },

  {
    path: 'login',
    loadComponent: () => import('./Pages/login/login').then((m) => m.Login),
  },

  {
    path: 'signup',
    loadComponent: () => import('./Pages/signup/signup').then((m) => m.Signup),
  },

  {
    path: '**',
    loadComponent: () => import('./Pages/not-found/not-found').then((m) => m.NotFound),
  },
];
