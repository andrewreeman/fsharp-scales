import SwiftUI

struct ContentView: View {
    @State private var scale = "Loading scale...";
    
    var body: some View {
        Text(scale)
            .onAppear {
                fetchData()
            }
    }
    
    private func fetchData() {
        guard let apiUrl = getApiUrl() else { return }
        let url = apiUrl.appending(path: "scale")
        
        URLSession.shared.dataTask(with: url) { data, response, error in
            if let unwrappedError = error {
                DispatchQueue.main.async {
                    scale = unwrappedError.localizedDescription
                }
                return
            }
            
            guard let data = data else { return }
            let scaleString = String.init(data: data, encoding: .utf8)
            DispatchQueue.main.async {
                scale = scaleString ?? "Error loading scale"
            }
        }.resume()
    }
    
    private func getApiUrl() -> URL? {
        guard
            let plistUrl = Bundle.main.url(forResource: "Scales", withExtension: "plist"),
            let plistData = try? Data.init(contentsOf: plistUrl)
        else { return nil }
        
        do
        {
            let plist = try PropertyListDecoder().decode(ScalesPListData.self, from: plistData)
            return URL.init(string: plist.apiUrl)
        } catch {
            DispatchQueue.main.async
            {
                scale = "\(error)"
            }
            return nil
        }
        
    }
}

#Preview {
    ContentView()
}

private struct ScalesPListData: Codable
{
    let apiUrl: String
}
