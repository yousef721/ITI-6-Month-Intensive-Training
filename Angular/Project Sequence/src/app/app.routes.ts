import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },

  {
    path: 'home',
    loadComponent: () => import('./pages/home/home').then((m) => m.Home),
  },

  {
    path: 'about',
    loadComponent: () => import('./pages/about/about').then((m) => m.About),
  },

  {
    path: 'profile',
    loadComponent: () => import('./pages/profile/profile').then((m) => m.Profile),
  },

  {
    path: 'posts',
    loadComponent: () => import('./pages/post-list/post-list').then((m) => m.PostList),
  },

  {
    path: 'posts/:id',
    loadComponent: () => import('./pages/post-details/post-details').then((m) => m.PostDetails),
  },

  {
    path: 'login',
    loadComponent: () => import('./pages/login/login').then((m) => m.Login),
  },

  {
    path: 'signup',
    loadComponent: () => import('./pages/signup/signup').then((m) => m.Signup),
  },

  {
    path: '**',
    loadComponent: () => import('./pages/not-found/not-found').then((m) => m.NotFound),
  },
];
