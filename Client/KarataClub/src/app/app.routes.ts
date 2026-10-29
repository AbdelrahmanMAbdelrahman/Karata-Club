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
import { SubscriptionListPage } from './Features/Subscriptions/Pages/Subscription-list-page/Subscription-list-page';
import { SubscriptionCreatePage } from './Features/Subscriptions/Pages/Subscription-create-page/Subscription-create-page';
import { SubscriptionPage } from './Features/Subscriptions/Pages/Subscription-page/Subscription-page';
import { CoursePage } from './Features/Courses/Pages/Course-page/Course-page';
import { CourseDetailPage } from './Features/Courses/Pages/Course-detail-page/Course-detail-page';
import { CourseListPage } from './Features/Courses/Pages/Course-list-page/Course-list-page';
import { CourseCreatePage } from './Features/Courses/Pages/Course-create-page/Course-create-page';
import { BeltRankCreatePage } from './Features/BeltRank/Pages/BeltRank-create-page/BeltRank-create-page';
import { BeltRankListPage } from './Features/BeltRank/Pages/BeltRank-list-page/BeltRank-list-page';
import { BeltRankDetailPage } from './Features/BeltRank/Pages/BeltRank-detail-page/BeltRank-detail-page';
import { BeltRankPage } from './Features/BeltRank/Pages/BeltRank-page/BeltRank-page';
import { EnrollmentPage } from './Features/Enrollments/Pages/Enrollment-page/Enrollment-page';
import { EnrollmentListPage } from './Features/Enrollments/Pages/Enrollment-list-page/Enrollment-list-page';
import { EnrollmentCreatePage } from './Features/Enrollments/Pages/Enrollment-create-page/Enrollment-create-page';
import { EnrollmentDetailPage } from './Features/Enrollments/Pages/Enrollment-detail-page/Enrollment-detail-page';
import { BeltTestPage } from './Features/BeltTests/Pages/BeltTest-page/BeltTest-page';
import { BeltTestDetailPage } from './Features/BeltTests/Pages/BeltTest-detail-page/BeltTest-detail-page';
import { BeltTestCreatePage } from './Features/BeltTests/Pages/BeltTest-create-page/BeltTest-create-page';
import { SessionPage } from './Features/Sessions/Pages/Session-page/Session-page';
import { SessionCreatePage } from './Features/Sessions/Pages/Session-create-page/Session-create-page';
import { SessionDetailPage } from './Features/Sessions/Pages/session-detail-page/session-detail-page';
import { AttendenceListPage } from './Features/Attendence/Pages/attendence-list-page/attendence-list-page';
import { AttendencePage } from './Features/Attendence/Pages/attendence-page/attendence-page';
import { AuthPage } from './Features/Auth/Pages/auth-page/auth-page';
import { LoginPage } from './Features/Auth/Pages/login-page/login-page';
import { AuthGuard } from './AuthGuard';

export const routes: Routes = [
    {path:"",component:HomePageComponent,canActivate:[AuthGuard],
        children:[
    {path:"InstructorPage",
        children:[
            {path:"InstructorCreatePage/:id",component:InstructorCreatePage,canActivate:[AuthGuard]},
            {path:"InstructorListPage",component:InstructorListPage,canActivate:[AuthGuard]},
            {path:"InstructorDetailPage/:id",component:InstructorDetailPage,canActivate:[AuthGuard]},
        ]},
    {path:"MemberPage",
        children:[
            {path:"MemberCreatePage/:id",component:MemberCreatePage,canActivate:[AuthGuard]},
            {path:"MemberListPage",component:MemberListPage,canActivate:[AuthGuard]},
            {path:"MemberDetailPage/:id",component:MemberDetailPage,canActivate:[AuthGuard]},
        ]},
    {path:"CoursePage",
        children:[
            {path:"CourseCreatePage/:id",component:CourseCreatePage,canActivate:[AuthGuard]},
            {path:"CourseListPage",component:CourseListPage,canActivate:[AuthGuard]},
            {path:"CourseDetailPage/:id",component:CourseDetailPage,canActivate:[AuthGuard]},
        ]},
        {path:"BeltRankPage",
        children:[
            {path:"BeltRankCreatePage/:id",component:BeltRankCreatePage,canActivate:[AuthGuard]},
            {path:"BeltRankListPage",component:BeltRankListPage,canActivate:[AuthGuard]},
            {path:"BeltRankDetailPage/:id",component:BeltRankDetailPage,canActivate:[AuthGuard]},
        ]},
    {path:"SubscriptionPage",
        children:[
            {path:"SubscriptionCreatePage/:id",component:SubscriptionCreatePage,canActivate:[AuthGuard]},
            {path:"SubscriptionListPage",component:SubscriptionListPage,canActivate:[AuthGuard]},
        ]},
    {path:"EnrollmentPage",
        children:[
            {path:"EnrollmentCreatePage/:id",component:EnrollmentCreatePage,canActivate:[AuthGuard]},
            {path:"EnrollmentListPage",component:EnrollmentListPage,canActivate:[AuthGuard]},
            {path:"EnrollmentDetailPage/:id",component:EnrollmentDetailPage,canActivate:[AuthGuard]},
        ]},
    {path:"AttendencePage",
        children:[
            {path:"AttendenceListPage/:id",component:AttendenceListPage,canActivate:[AuthGuard]},
        ]},
    {path:"SessionPage",
        children:[
            {path:"SessionCreatePage/:id",component:SessionCreatePage,canActivate:[AuthGuard]},
            {path:"SessionDetailPage/:id",component:SessionDetailPage,canActivate:[AuthGuard]},
        ]},
        {path:"BeltTestPage",
        children:[
            {path:"BeltTestCreatePage/:id",component:BeltTestCreatePage,canActivate:[AuthGuard]},
            {path:"BeltTestDetailPage/:id",component:BeltTestDetailPage,canActivate:[AuthGuard]},
        ]},
    ]
},
{path:"AuthPage",component:AuthPage,
children:[
    {path:"Login",component:LoginPage},
]},
];
