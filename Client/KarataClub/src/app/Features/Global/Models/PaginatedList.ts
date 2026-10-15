export interface PaginatedList<T>{
    items:Array<T>,
    pageNumber:number,
    totalPages:number,
    hasNextPage:boolean,
    hasPreviousPage:boolean
}