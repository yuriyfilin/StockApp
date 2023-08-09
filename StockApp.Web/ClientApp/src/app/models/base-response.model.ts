export class BaseResponse<TResponse> {
  data: TResponse;
  message: string;
  success: boolean;
}

