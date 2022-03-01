 public ActionResult FileUpload(HttpPostedFileBase file)
        {
            try
            {
                // file에 업로드하고 그 파일 사이즈가 0byte 이상이면
                if (file != null && file.ContentLength > 0)
                {
                    // file이름 취득
                    string filename = Path.GetFileName(file.FileName);
                    // file확장자 취득
                    string mimeType = Path.GetExtension(file.FileName);
                    // 저장할 경로 설정
                    string savepath = Path.Combine(@"(저장할 위치)", filename);
                    // 파일 저장
                    file.SaveAs(savepath);

                    //파일 이름 GUID로 변경
                    string pathCC = @"(저장할 위치)"+filename;
                    string keyTT = Guid.NewGuid().ToString();

                    string NameOfFill = keyTT + mimeType;

                    Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(pathCC, NameOfFill);

                    //최근 데이터에 바뀐 fill이름 삽입
                    service.MinFillName(NameOfFill);

                    // 메시지 설정
                    ViewBag.Message = "성공";
                }
                else
                {
                    // 메시지 설정
                    ViewBag.Message = "File upload failed";
                }
            }
            catch
            {
                // 메시지 설정
                ViewBag.Message = "File upload failed";
            }
            // /View/board/create.cshtml를 렌더링한다.
            return View("Create");
        }
