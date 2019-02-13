import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AngularEditorConfig } from '@kolkov/angular-editor';
import {EditorConfigService} from '../services/editor-config.service';
import { ArticlesClient, ArticleDto, ArticleUpdateDto } from '../../api.client.generated';

@Component({
  selector: 'app-news-edit',
  templateUrl: './news-edit.component.html',
  styleUrls: ['./news-edit.component.scss']
})
export class NewsEditComponent implements OnInit {

  editForm: FormGroup;
  errorMessage: string;
  editorConfig: AngularEditorConfig;
  submitted = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private client: ArticlesClient,
    private fb: FormBuilder,
    private configService: EditorConfigService) {}

  ngOnInit(): void {
    this.editorConfig = this.configService.config;

    this.editForm = this.fb.group({
      id: ['', [Validators.required]],
      title: ['', [Validators.required, Validators.maxLength(1000)]],
      headline: ['', [Validators.required, Validators.maxLength(1000)]],
      body: ['', [Validators.required, Validators.maxLength(4000)]],
      imageUri: ['', [Validators.required, Validators.maxLength(100)]]
    });

    const resolvedData: ArticleDto = this.route.snapshot.data.resolvedData;
    this.onArticleRetrieved(resolvedData);
  }

  onArticleRetrieved(article: ArticleDto): void {
    this.editForm.setValue({
      id: article.id,
      title: article.title,
      headline: article.headline,
      body: article.body,
      imageUri: article.imageUri
    });
  }

  redirectToView(articleId: number) {
    this.router.navigate(['/news', articleId]);
  }

  save(value: ArticleUpdateDto, valid: boolean): void {
      this.submitted = true;
      if (valid) {
        this.client.updateArticle(value).subscribe(result => {
          this.redirectToView(value.id);
        }, error => console.error(error));
      }
  }

  cancel(): void {
    this.redirectToView(this.editForm.controls.id.value);
  }

  delete(): void {
    this.client.deleteArticle(this.editForm.controls.id.value);
  }
}
