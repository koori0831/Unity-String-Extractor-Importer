## Unity String Extractor & Importer

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Unity String Extractor & Importer는 Unity 게임의 텍스트를 손쉽게 추출하고 번역하여 다시 적용할 수 있는 강력한 도구입니다.

일반적으로 많이 사용되는 Unity의 스트링 방식 중 하나를 지원하며, [Example.txt](https://github.com/koori0831/Unity-String-Extractor-Importer/blob/main/Example.txt)를 열어 확인할 수 있습니다.(정해진 형식 외의 스트링은 작업할 수 없습니다!)

🚀 **주요 기능**

* **자동화된 추출 및 임포트:** Unity 스트링 파일에서 텍스트를 자동으로 추출하고, 번역된 텍스트를 다시 게임에 적용합니다. 
* **편리한 CSV 편집:** 추출된 텍스트는 CSV 파일 형식으로 제공되어 Excel 또는 Google Sheets와 같은 스프레드시트 프로그램에서 쉽게 편집할 수 있습니다.
* **강력한 오류 처리:** CSV 파일의 형식 오류를 감지하고, 오류 메시지를 자세히 기록하여 문제 해결을 돕습니다.
* **대용량 파일 지원:** 스트리밍 처리 방식을 사용하여 대용량 스트링 파일도 효율적으로 처리합니다.
* **사용자 친화적인 GUI:** 직관적인 GUI를 통해 누구나 쉽게 사용할 수 있습니다.

📥 **다운로드**

최신 버전의 프로그램은 [Releases 페이지](https://github.com/koori0831/Unity-String-Extractor-Importer/releases)에서 다운로드할 수 있습니다.

🧰 **사용 방법**

1. "Unity String File" 텍스트 박스 옆의 "Browse" 버튼을 클릭하여 Unity 스트링 파일을 선택합니다.(.txt형식을 추천합니다. 주의: UABEA DUMP방식으로만 테스트됨.)
2. "CSV File" 텍스트 박스 옆의 "Browse" 버튼을 클릭하여 CSV 파일을 선택합니다. (처음 사용 시에는 자동으로 생성됩니다.)
3. "Extract Strings" 버튼을 클릭하여 Unity 스트링 파일에서 텍스트를 추출합니다.
4. 생성된 CSV 파일을 Excel 또는 Google Sheets에서 열고 "m_Localized" 열의 텍스트를 번역합니다.
5. "Import Strings" 버튼을 클릭하여 번역된 CSV 파일을 Unity 스트링 파일에 적용합니다.

🛠️ **개발 환경**

* .NET Framework 4.7.2
* Visual Studio 2022
* Microsoft.VisualBasic.FileIO (CSV 파싱)

📄 **라이선스**

MIT License - 자유롭게 사용, 수정, 배포할 수 있습니다.

🙌 **기여**

버그 보고, 기능 제안, 코드 기여를 환영합니다!
