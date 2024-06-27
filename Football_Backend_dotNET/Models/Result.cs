using System;
namespace Football_Backend_dotNET.Models
{
	public class Result
	{
        // 属性才能正常序列化
        public int code { get; set; }  // 响应码 1为成功 0为失败
        public string msg { get; set; }  // 响应信息 "success"或错误信息
        public object? data { get; set; }  // 返回数据

        public Result(int code, string msg, object? data)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        public static Result Success()
        {
            return new Result(1, "success", null);
        }  // 无返回数据 成功
        public static Result Success(object data)
        {
            return new Result(1, "success", data);
        }  // 有返回数据 成功
        public static Result Error(string msg)
        {
            return new Result(0, msg, null);
        }  // 失败
    }
}

