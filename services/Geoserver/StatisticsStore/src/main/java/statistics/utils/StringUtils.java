package statistics.utils;

import java.util.List;

/**
 *
 * @author Andre Matos
 */
public class StringUtils {

    public static String join(List<String> input, String delimiter) {
        
        StringBuilder sb = new StringBuilder();
        if(input != null) {
            for(String value : input)
            {
                sb.append(value);
                sb.append(delimiter);
            }
            int length = sb.length();
            if(length > 0)
            {
                // Remove the extra delimiter
                sb.setLength(length - delimiter.length());
            }
        }
        return sb.toString();
    }
    
}
