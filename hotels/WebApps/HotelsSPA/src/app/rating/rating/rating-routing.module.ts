import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RatingComponent } from './rating.component';
import { ShowReviewsComponent } from './components/show-reviews/show-reviews.component';

const routes: Routes = [{ path: '', component: RatingComponent },
{ path: 'show-reviews/:hotelId', component: ShowReviewsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RatingRoutingModule { }
