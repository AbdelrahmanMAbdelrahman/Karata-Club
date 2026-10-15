import { Routes } from '@angular/router';
import { HomePageComponent } from './Features/Global/Components/home-page-component/home-page-component';
import { InstructorPage } from './Features/Instructors/Pages/instructor-page/instructor-page';
import { InstructorCreatePage } from './Features/Instructors/Pages/instructor-create-page/instructor-create-page';
import { InstructorDetailPage } from './Features/Instructors/Pages/instructor-detail-page/instructor-detail-page';
import { InstructorListPage } from './Features/Instructors/Pages/instructor-list-page/instructor-list-page';

export const routes: Routes = [
    {path:"",component:HomePageComponent,
        children:[
    {path:"InstructorPage",component:InstructorPage,
        children:[
            {path:"InstructorCreatePage/:id",component:InstructorCreatePage},
            {path:"InstructorListPage",component:InstructorListPage},
            {path:"InstructorDetailPage/:id",component:InstructorDetailPage},
        ]}

        ]
    }
];
