import { Routes } from '@angular/router';
import { HomePageComponent } from './Features/Global/Components/home-page-component/home-page-component';
import { InstructorPage } from './Features/Instructors/Pages/instructor-page/instructor-page';
import { InstructorCreatePage } from './Features/Instructors/Pages/instructor-create-page/instructor-create-page';
import { InstructorDetailPage } from './Features/Instructors/Pages/instructor-detail-page/instructor-detail-page';
import { InstructorListPage } from './Features/Instructors/Pages/instructor-list-page/instructor-list-page';
import { MemberPage } from './Features/Members/Pages/Member-page/Member-page';
import { MemberCreatePage } from './Features/Members/Pages/Member-create-page/Member-create-page';
import { MemberDetailPage } from './Features/Members/Pages/Member-detail-page/Member-detail-page';
import { MemberListPage } from './Features/Members/Pages/Member-list-page/Member-list-page';

export const routes: Routes = [
    {path:"",component:HomePageComponent,
        children:[
    {path:"InstructorPage",component:InstructorPage,
        children:[
            {path:"InstructorCreatePage/:id",component:InstructorCreatePage},
            {path:"InstructorListPage",component:InstructorListPage},
            {path:"InstructorDetailPage/:id",component:InstructorDetailPage},
        ]},
    {path:"MemberPage",component:MemberPage,
        children:[
            {path:"MemberCreatePage/:id",component:MemberCreatePage},
            {path:"MemberListPage",component:MemberListPage},
            {path:"MemberDetailPage/:id",component:MemberDetailPage},
        ]},

        ]
    }
];
