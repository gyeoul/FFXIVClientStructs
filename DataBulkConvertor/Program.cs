// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

const string yamlPath = @"..\..\..\..\ida\data.yml";
const string txtPath = @"..\..\..\..\ida\data-mismatch3.txt";
// 수정된 내용을 저장할 임시 파일 경로
const string tempYamlPath = "data_temp.yml";

if (!File.Exists(yamlPath)) {
    Console.WriteLine("YAML 파일 경로가 잘못되었습니다.");
    return;
}
if (!File.Exists(txtPath)) {
    Console.WriteLine("TXT 파일 경로가 잘못되었습니다.");
    return;
}
// YAML 파일 수정
using (StreamReader txtReader = new StreamReader(txtPath))
using (StreamReader yamlReader = new StreamReader(yamlPath))
using (StreamWriter yamlWriter = new StreamWriter(tempYamlPath)) {
    // txt 파일에서 "original -> resolved" 매핑을 읽어오기
    var replacements = new Dictionary<string, string>();
    string pattern = @"data\.yml has (?<original>[A-Fa-f0-9]+)";
    while (!txtReader.EndOfStream) {
        string line = txtReader.ReadLine();
        Match match = Regex.Match(line, pattern);
        if (match.Success) {
            string originalValue = match.Groups["original"].Value;
            if (line.Contains("resolved to")) {
                string resolvedValue = line.Split("resolved to")[1].Split(',')[0].Trim();
                if (originalValue.Length < resolvedValue.Length) {
                    originalValue = originalValue.PadLeft(resolvedValue.Length, '0');
                } else {
                    resolvedValue = resolvedValue.PadLeft(originalValue.Length, '0');
                }
                replacements[originalValue] = resolvedValue;
            }
        }

    }

    // YAML 파일에서 original 값을 resolved 값으로 치환
    while (!yamlReader.EndOfStream) {
        string yamlLine = yamlReader.ReadLine();
        foreach (var replacement in replacements) {
            if (yamlLine.Contains(replacement.Key)) {
                yamlLine = yamlLine.Replace(replacement.Key, replacement.Value);
                break;
            }
        }
        yamlWriter.WriteLine(yamlLine);
    }
}

// 원본 파일 덮어쓰기
File.Delete(yamlPath);
File.Move(tempYamlPath, yamlPath);

Console.WriteLine("YAML 파일이 성공적으로 업데이트되었습니다.");
