import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { AuthService } from '../../services/auth.service';
import { ArticleDto } from 'src/app/api.client.generated';

@Component({
  selector: 'app-news-detail',
  templateUrl: './news-detail.component.html',
  styleUrls: ['./news-detail.component.scss']
})
export class NewsDetailComponent implements OnInit {

  article: ArticleDto;
  errorMessage: string;

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService) { }

  ngOnInit(): void {
    const resolvedData: ArticleDto = this.route.snapshot.data.resolvedData;
    // this.errorMessage = resolvedData.error;
    this.onArticleRetrieved(resolvedData);
  }

  isEmployee() {
    return this.authService.isEmployee();
  }

  onArticleRetrieved(article: ArticleDto): void {
    this.article = article;
  }

}
