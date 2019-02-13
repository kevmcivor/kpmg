import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularEditorModule } from '@kolkov/angular-editor';

import { NewsArchiveComponent } from './news-archive/news-archive.component';
import { NewsLatestComponent } from './news-latest/news-latest.component';
import { NewsEditComponent } from './news-edit/news-edit.component';
import { NewsAddComponent } from './news-add/news-add.component';

import { ArticlesClient, CommentsClient, RatingsClient} from '../api.client.generated';
import { NewsDetailComponent } from './news-detail/news-detail.component';
import { ArticleResolverService } from './services/article-resolver.service';
import { EditorConfigService } from './services/editor-config.service';
import { AuthGuardService } from '../services/auth-guard.service';
import { AuthGuardAdminService } from '../services/auth-guard-admin.service';
import { CommentAddComponent } from './comment-add/comment-add.component';
import { RatingAddComponent } from './rating-add/rating-add.component';

const routes: Routes = [
  { path: 'news-latest', component: NewsLatestComponent, canActivate: [AuthGuardService]  },
  { path: 'news-archive', component: NewsArchiveComponent , canActivate: [AuthGuardService] },
  { path: 'news-add', component: NewsAddComponent, canActivate: [AuthGuardAdminService] },
  {
    path: ':id',
    component: NewsDetailComponent,
    canActivate: [AuthGuardService],
    resolve: { resolvedData: ArticleResolverService }
  },
  {
    path: ':id/edit',
    component: NewsEditComponent,
    canActivate: [AuthGuardAdminService],
    resolve: { resolvedData: ArticleResolverService }
  },
];

@NgModule({
  declarations: [
    NewsArchiveComponent,
    NewsLatestComponent,
    NewsEditComponent,
    NewsAddComponent,
    NewsDetailComponent,
    CommentAddComponent,
    RatingAddComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    [RouterModule.forChild(routes)],
    AngularEditorModule,
    NgbModule
  ],
  providers: [
    ArticlesClient,
    CommentsClient,
    RatingsClient,
    ArticleResolverService,
    EditorConfigService ]
})
export class NewsModule {

}
