import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { Observable } from 'rxjs';

import { ArticlesClient, ArticleDto } from 'src/app/api.client.generated';


@Injectable({
  providedIn: 'root'
})
export class ArticleResolverService implements Resolve<ArticleDto> {

  constructor(private client: ArticlesClient ) {  }

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<ArticleDto> {

      const id = route.paramMap.get('id');
      if (isNaN(+id)) {
        const message = `Article id was not a number: ${id}`;
        console.error(message);
        // return of({ news: null, error: message });
      }

      // ng destroy
      return this.client.getArticle(route.params.id);
    }
}
