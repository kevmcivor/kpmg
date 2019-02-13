import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { ArticlesClient, ArticleDto } from '../../api.client.generated';

@Component({
  selector: 'app-news-latest',
  templateUrl: './news-latest.component.html',
  styleUrls: ['./news-latest.component.scss']
})
export class NewsLatestComponent implements OnInit {

  recentArticles$: Observable<ArticleDto[]>;
  articles: ArticleDto[];

  constructor(private _client: ArticlesClient) { }

  ngOnInit() {
    // ngDestroy
    this.recentArticles$ = this._client.getRecent();
  }
}
